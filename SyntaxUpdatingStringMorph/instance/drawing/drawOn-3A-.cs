drawOn: aCanvas

	| tempForm strm where chars wid spaceWidth putLigature topOfLigature sizeOfLigature colorOfLigature dots charZero canvas f |

	tempForm _ Form extent: self extent depth: aCanvas depth.
	canvas _ tempForm getCanvas.
	f _ self fontToUse.
	spaceWidth _ f widthOf: Character space.
	strm _ ReadStream on: contents.
	charZero _ Character value: 0.	"a marker for center dot ·"
	where _ 0@0.
	topOfLigature _ self height // 2 - 1.
	sizeOfLigature _ (spaceWidth-2)@(spaceWidth-2).
	colorOfLigature _ Color black alpha: 0.45	"veryLightGray".
	dots _ OrderedCollection new.
	putLigature _ [
		dots add: ((where x + 1) @ topOfLigature extent: sizeOfLigature).
		where _ where + (spaceWidth@0)].
	strm peek = charZero ifTrue: [
		strm next.
		putLigature value].
	[strm peek = charZero] whileTrue: [strm next].
	[strm atEnd] whileFalse: [
		chars _ strm upTo: charZero.
		wid _ f widthOfString: chars.
		canvas drawString: chars at: where.
		where _ where + (wid@0).
		strm atEnd ifFalse: [putLigature value.
			[strm peek = charZero] whileTrue: [strm next]].
	].
	aCanvas paintImage: tempForm at: self topLeft.
	dots do: [ :each |
		aCanvas 
			fillRectangle: (each translateBy: self topLeft) 
			fillStyle: colorOfLigature.
	].
