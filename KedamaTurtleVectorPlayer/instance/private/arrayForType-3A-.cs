arrayForType: typeName

	| newArray |
	(typeName = #Number) ifTrue: [
		newArray _ KedamaFloatArray new: self size.
	].
	(typeName = #Color) ifTrue: [
		newArray _ WordArray new: self size.
	].
	(typeName = #Boolean) ifTrue: [
		newArray _ ByteArray new: self size.
	].

	newArray ifNil: [
		newArray _ Array new: self size.
	].

	^ newArray.
