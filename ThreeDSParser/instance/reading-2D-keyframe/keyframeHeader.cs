keyframeHeader
	"Subchunk of keyframeData"
	
	| name len revision |
	revision := self short.
	name := self cString.
	len := self long.
	log == nil ifFalse: [log crtab: indent; 
		nextPutAll: 'File: '; print: name; nextPutAll: ' frames: '; print: len; nextPutAll: ' revision: '; print: revision].
	^Array 
		with: (#frames->len)
		with: (#file->name)