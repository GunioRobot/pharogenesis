storeHtmlPageIn: aFileDirectory
	"Prepare the HTML wrapper for the current project"
	| file page |
	file _ aFileDirectory forceNewFileNamed: (self name, FileDirectory dot,'html').
	page _ self htmlPagePrototype.
	page _ page copyReplaceAll: '$$PROJECT$$' with: self versionedFileName.
	page _ page copyReplaceAll: '$$WIDTH$$' with: world bounds width printString.
	page _ page copyReplaceAll: '$$HEIGHT$$' with: world bounds height printString.
	page _ page copyReplaceAll: String cr with: String lf. "not sure if necessary..."
	file nextPutAll: page.
	file close.