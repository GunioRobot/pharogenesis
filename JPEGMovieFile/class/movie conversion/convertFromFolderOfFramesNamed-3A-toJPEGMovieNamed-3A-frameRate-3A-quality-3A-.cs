convertFromFolderOfFramesNamed: folderName toJPEGMovieNamed: jpegFileName frameRate: frameRate quality: quality
	"Convert a folder of frames into a JPEG movie. The named folder is assumed to contain only image files, all of the same size, and whose alphabetical order (case-insensitive) is the sequence in which they will appear in in the movie. A useful convention is to make the image files end in zero-padded frame numbers, for example 'frame0001.bmp', 'frame0002.bmp', etc. The image files can be any format readable by Form>fromFileNamed:. The movie frame extent is taken from the first frame file."

	| jpegFile dir fileNames frameCount frameForm frameOffsets |
	(FileDirectory default directoryExists: folderName)
		ifFalse: [^ self inform: 'Folder not found: ', folderName].
	jpegFile _ (FileStream newFileNamed: jpegFileName) binary.
	dir _ FileDirectory default on: folderName.
	fileNames _ self sortedByFrameNumber: dir fileNames.
	frameCount _ fileNames size.
	frameForm _ Form fromFileNamed: (dir fullNameFor: fileNames first).

	"write header"
	self writeHeaderExtent: frameForm extent
		frameRate: frameRate
		frameCount: frameCount
		soundtrackCount: 0
		on: jpegFile.

	"convert and write frames"
	frameOffsets _ Array new: frameCount + 1.
	1 to: frameCount do: [:i |
		frameOffsets at: i put: jpegFile position.
		frameForm _ Form fromFileNamed: (dir fullNameFor: (fileNames at: i)).
		self writeFrame: frameForm on: jpegFile quality: quality displayFlag: true].
	frameOffsets at: (frameCount + 1) put: jpegFile position.
	self updateFrameOffsets: frameOffsets on: jpegFile.

	jpegFile close.
	Display restore.
