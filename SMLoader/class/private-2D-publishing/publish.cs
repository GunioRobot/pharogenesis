publish
	| pi versionNo packagedFileName packageFile sd initialPackagedFileName |
	pi _ PackageInfo named: 'SM-Loader'.
	versionNo := FillInTheBlank request: 'Version number for this file?'.
	pi fileOut.
	initialPackagedFileName := pi externalName,'.st'.
	packagedFileName _ pi externalName, '.', versionNo asString, (FileDirectory dot, FileStream cs).
	FileDirectory default rename: initialPackagedFileName toBe: packagedFileName.
	GZipWriteStream compressFile: packagedFileName.
	packageFile := FileDirectory default readOnlyFileNamed: packagedFileName.
	sd := ServerDirectory new.
	sd
		user: 'dvf';
		server: 'modules.squeakfoundation.org';
		password: (FillInTheBlank request: 'password?');
		directory: 'Packages/';
		putFile: packageFile named: packagedFileName