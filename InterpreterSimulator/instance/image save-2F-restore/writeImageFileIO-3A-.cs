writeImageFileIO: numberOfBytesToWrite
	"Actually emit the first numberOfBytesToWrite object memory bytes onto the snapshot."

	| headerSize file |

	headerSize _ 64.

	[
		file _ (FileStream fileNamed: imageName) binary.
		file == nil ifTrue: [^nil].
	
		{
			self imageFormatVersion.
			headerSize.
			numberOfBytesToWrite.
			self startOfMemory.
			specialObjectsOop.
			lastHash.
			self ioScreenSize.
			fullScreenFlag.
			extraVMMemory
		}
			do: [:long | self putLong: long toFile: file].
	
		"Pad the rest of the header."
		7 timesRepeat: [self putLong: 0 toFile: file].
	
		"Position the file after the header."
		file position: headerSize.
	
		"Write the object memory."
		1
			to: numberOfBytesToWrite // 4
			do: [:index |
				self
					putLong: (memory at: index)
					toFile: file].
	
		self success: true
	]
		ensure: [file close]