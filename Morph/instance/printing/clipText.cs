clipText
	"Copy the text in the receiver or in its submorphs to the clipboard"
	| content |
	"My own text"
	content _ self userString.
	"Or in my submorphs"
	content ifNil: [
		| list |
		list _ self allStringsAfter: nil.
		list notEmpty ifTrue: [
			content _ String streamContents: [:stream |
				list do: [:each | stream nextPutAll: each; cr]]]].
	"Did we find something?"
	content
		ifNil: [self flash "provide feedback"]
		ifNotNil: [Clipboard clipboardText: content].