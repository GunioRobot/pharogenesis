copyListToClipboard
	"Copy my items to the clipboard as a multi-line string"

	| stream |
	stream _ WriteStream on: (String new: list size * 40).
	list do: [:ea | stream nextPutAll: ea asString] separatedBy: [stream nextPut: Character cr].
	Clipboard clipboardText: stream contents