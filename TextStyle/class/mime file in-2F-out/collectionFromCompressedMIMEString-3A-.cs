collectionFromCompressedMIMEString: aString
	"aString holds a compressed, Base64 representation of a SmartRefStream storage of a TextStyle.
	Install the TextStyle."

	| this newName style heights data |
	data := (Base64MimeConverter mimeDecode: aString as: String) unzipped.
	(RWBinaryOrTextStream with: data) reset; fileIn.
	this := SmartRefStream scannedObject.

	"now install it"

	newName _ this fontArray first familyName.
	this fontArray do: [:aFont | aFont familyName = newName ifFalse: [
		self error: 'All must be same family']].
	style _ TextConstants at: newName asSymbol ifAbsent: [
		^ TextConstants at: newName asSymbol put: this].		"new family"
	this fontArray do: [:aFont | "add new fonts"
		heights _ style fontArray collect: [:bFont | bFont height].
		(heights includes: aFont height) ifFalse: [
			style fontAt: style fontArray size + 1 put: aFont]].
