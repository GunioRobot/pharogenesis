initialize
	"Initialize the receiver."

	selectedFileIndex := 0.
	fileNameText := ''.
	self
		answerPathName;
		directories: self initialDirectories;
		showDirectoriesInFileList: true;
		fileSelectionBlock: self defaultFileSelectionBlock;
		fileSortBlock: self defaultFileSortBlock.
	super initialize