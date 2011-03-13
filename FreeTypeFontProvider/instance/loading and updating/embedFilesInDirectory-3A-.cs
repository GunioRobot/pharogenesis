embedFilesInDirectory: aFileDirectory
	"embed all the files in aFileDirectory
	
	FreeTypeFontProvider current embedFilesInDirectory: (FileDirectory default directoryNamed: 'Fonts')
	"
	| filestream bytes basename |
	aFileDirectory fileNames do:[:filename |
		filestream  := aFileDirectory fileNamed: filename.
		filestream binary.
		bytes := filestream contents.
		filestream close.
		basename := FileDirectory baseNameFor: filename.
		self addFromFileContents: bytes baseName: basename].
	"update so that missing text styles are created."
	self updateFromSystem.
	"clear all the logicalFonts realFonts so that embedded fonts take precedence over external ones"
	LogicalFont allInstances do:[:logFont | logFont clearRealFont]
		