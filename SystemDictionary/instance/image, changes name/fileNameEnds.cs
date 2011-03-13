fileNameEnds
	"Answer the appropriate suffixes for image and changes files."

	| pairs |
	pairs _ #(
		('image' 'changes')
		('image.IMA' 'changes.CHA')
		('IMA' 'CHA')).
	pairs do: [:pair |
		(self imageName endsWith: pair first) ifTrue: [^ pair]].

	self error:
'The image file must end with one of
' , (pairs collect: [:pair | pair first]) printString
