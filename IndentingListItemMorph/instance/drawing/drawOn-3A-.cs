drawOn: aCanvas

	| tRect sRect columnRect columnScanner columnData columnLeft colorToUse |

	tRect := self toggleRectangle.
	sRect := bounds withLeft: tRect right + 3.
	self drawToggleOn: aCanvas in: tRect.
	colorToUse _ complexContents preferredColor ifNil: [color].
	(container columns isNil or: [(contents asString indexOf: Character tab) = 0]) ifTrue: [
		aCanvas text: contents asString bounds: sRect font: font color: colorToUse.
	] ifFalse: [
		columnLeft _ sRect left.
		columnScanner _ ReadStream on: contents asString.
		container columns do: [ :width |
			columnRect _ columnLeft @ sRect top extent: width @ sRect height.
			columnData _ columnScanner upTo: Character tab.
			columnData isEmpty ifFalse: [
				aCanvas text: columnData bounds: columnRect font: font color: colorToUse.
			].
			columnLeft _ columnRect right + 5.
		].
	]