print: str withFont: font
	"Print the given string in the given font at the current heading"
	| lineStart form charStart rowStart scale wasDown bb pix |
	scale _ sourceForm width.
	wasDown _ penDown.
	lineStart _ location.
	str do:
		[:char |
		char = Character cr ifTrue:
			[self place: lineStart; up; turn: 90; go: font height*scale; turn: -90; down]
		ifFalse:
			[form _ font characterFormAt: char.
			charStart _ location.
wasDown ifTrue: [
			self up; turn: -90; go: font descent*scale; turn: 90; down.
			0 to: form height-1 do:
				[:y |
				rowStart _ location.
				bb _ BitBlt bitPeekerFromForm: form.
				pix _ RunArray newFrom:
					((0 to: form width-1) collect: [:x | bb pixelAt: x@y]).
				pix runs with: pix values do:
					[:run :value |
					value = 0
						ifTrue: [self up; go: run*scale; down]
						ifFalse: [self go: run*scale]].
				self place: rowStart; up; turn: 90; go: scale; turn: -90; down].
].
			self place: charStart; up; go: form width*scale; down].
			].
	wasDown ifFalse: [self up]
"
Display restoreAfter:
[Pen new squareNib: 2; color: Color red; turn: 45;
	print: 'The owl and the pussycat went to sea
in a beautiful pea green boat.' withFont: (TextStyle default fontAt: 1)]
"