contents
	"Answer the contents of the file, reading it first if needed."
	"Possible brevityState values:
		FileList,
		fullFile, briefFile, needToGetFull, needToGetBrief,
		fullHex, briefHex, needToGetFullHex, needToGetBriefHex"

	(listIndex = 0) | (brevityState == #FileList) ifTrue: [
		"no file selected"
		contents _ self defaultContents.
		brevityState _ #FileList.
		^ contents].
	brevityState == #fullFile ifTrue: [^ contents].
	brevityState == #needToGetFull ifTrue: [
		contents _ self readContentsBrief: false.
		brevityState _ #fullFile.	"don't change till actually read"
		^ contents].
	brevityState == #fullHex ifTrue: [^ contents].
	brevityState == #needToGetFullHex ifTrue: [
		contents _ self readContentsHex: false.
		brevityState _ #fullHex.
		^ contents].
	brevityState == #briefHex ifTrue: [^ contents].
	brevityState == #needToGetBriefHex ifTrue: [
		contents _ self readContentsHex: true.
		^ contents].
	brevityState == #briefFile ifTrue: [^ contents].
	"default"
	"brevityState == #needToGetBrief" true ifTrue: [
		contents _ self readContentsBrief: true.
		brevityState _ #briefFile.	"don't change till actually read"
		^ contents].
