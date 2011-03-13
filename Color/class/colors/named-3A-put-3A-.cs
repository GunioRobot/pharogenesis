named: newName put: aColor
	"Add a new color to the list and create an access message and a class variable for it.  The name should start with a lowercase letter.  (The class variable will start with an uppercase letter.)  (Color names) gives a list of the colors.  6/13/96 tk"
	| str cap sym accessor csym |
	(aColor isKindOf: self) ifFalse: [^ self error: 'not a Color'].
	str _ newName asString.
	sym _ str asSymbol.
	cap _ str copy.
	cap at: 1 put: (cap at: 1) asUppercase.
	csym _ cap asSymbol.
	(self class canUnderstand: sym) ifFalse: [
		"define access message"
		accessor _ str, (String with: Character cr with: Character tab), 			'^', cap.
		self class compile: accessor
			classified: 'colors'].
	(self classPool includesKey: csym) ifFalse: [
		self addClassVarName: cap].
	(ColorNames includes: sym) ifFalse: [
		ColorNames add: sym].
	^ self classPool at: csym put: aColor