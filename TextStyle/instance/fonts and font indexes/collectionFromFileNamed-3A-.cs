collectionFromFileNamed: fileName
	"Read the file.  It is an TextStyle whose StrikeFonts are to be added to the system.  (Written by fooling SmartRefStream, so it won't write a DiskProxy!)  These fonts will be added to the master TextSytle for this font family.  
	To write out fonts: 
		| ff | ff _ ReferenceStream fileNamed: 'new fonts'.
		TextConstants at: #forceFontWriting put: true.
		ff nextPut: (TextConstants at: #AFontName).
			'do not mix font families in the TextStyle written out'.
		TextConstants at: #forceFontWriting put: false.
		ff close.
	To read: (TextStyle default collectionFromFileNamed: 'new fonts')
*** Do not remove this method *** "

	| ff this newName style heights |
	ff _ ReferenceStream fileNamed: fileName.
	this _ ff nextAndClose.	"Only works if file created by special code above"
	newName _ this fontArray first name.
	this fontArray do: [:aFont | aFont name = newName ifFalse: [
		self error: 'All must be same family']].
	style _ TextConstants at: newName asSymbol ifAbsent: [
		^ TextConstants at: newName asSymbol put: this].		"new family"
	this fontArray do: [:aFont | "add new fonts"
		heights _ style fontArray collect: [:bFont | bFont height].
		(heights includes: aFont height) ifFalse: [
			style fontAt: style fontArray size + 1 put: aFont]].
