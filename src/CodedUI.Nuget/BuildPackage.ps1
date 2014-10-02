$ErrorActionPreference = "Stop"

write-progress -activity "Building Solution" 

$msBuildPath = (join-path $env:systemroot "\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe");   
iex "$msBuildPath ..\CodedUI.jQueryExtensions.sln /t:rebuild /p:Configuration=Release /p:VisualStudioVersion=12.0" 

if($LASTEXITCODE -ne 0){
	write-error -Message "Build Failed"
}else{
	Write-Host "Build Succeeded" -ForegroundColor Green
}

write-progress -activity "Building Solution"  -Completed


write-progress -activity "Creating package" 
[Xml]$xml = Get-Content "CodedUI.jQueryExtensions.nuspec";
$namespaceManager = [System.Xml.XmlNamespaceManager]$xml.NameTable;
$namespaceManager.AddNamespace("a","http://schemas.microsoft.com/packaging/2013/01/nuspec.xsd")

$version = $xml.SelectSingleNode("a:package/a:metadata/a:version", $namespaceManager).InnerText;
$tempPath = [System.IO.Path]::GetTempPath();
$directoryName = "NugetPrePackage_" + $version;
$fullyQualifiedDirectoryName = Join-Path $tempPath $directoryName

#remove the temp directory if already there
if(test-path $fullyQualifiedDirectoryName){
	rm $fullyQualifiedDirectoryName -Force -Recurse|out-null
}

$toolsDir = join-path $fullyQualifiedDirectoryName "tools" 
$contentDirectory = join-path $fullyQualifiedDirectoryName "content" 
$libDirectory = join-path $contentDirectory "lib"
$net40 = join-path $libDirectory "net40"

mkdir $fullyQualifiedDirectoryName -Force |out-null
mkdir $toolsDir -Force |out-null
mkdir $contentDirectory -Force |out-null
mkdir $libDirectory -Force  |out-null
mkdir $net40 -Force  |out-null

write-host "Directories made" -ForegroundColor Green

#copy assemblies
copy ..\CodedUI.jQueryExtensions\bin\release\CodedUI.jQueryExtensions.dll -Destination $net40 -Force  |out-null
copy ..\CodedUI.jQueryExtensions\bin\release\CodedUI.jQueryExtensions.XML -Destination $net40 -Force  |out-null
write-host "Assemblies copied" -ForegroundColor Green

#copy init.ps1 script
copy .\Tools\init.ps1 -Destination $toolsDir -Force  |out-null
write-host "Init.ps1 copied" -ForegroundColor Green

#copy transform
copy .\content\app.config.transform -Destination $contentDirectory -Force  |out-null
write-host "Transform copied" -ForegroundColor Green

#copy copy nuspec
copy .\CodedUI.jQueryExtensions.nuspec -Destination $fullyQualifiedDirectoryName -Force  |out-null
write-host "Nuspec copied" -ForegroundColor Green

.\NuGet.exe Pack (join-path $fullyQualifiedDirectoryName "CodedUI.jQueryExtensions.nuspec")
write-progress -activity "Creating package" -Completed


write-progress -activity "Cleaning Up" 
rm $fullyQualifiedDirectoryName -Force -Recurse|out-null
write-progress -activity "Cleaning Up" -Completed



