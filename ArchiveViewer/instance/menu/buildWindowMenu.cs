buildWindowMenu
	| menu |
	menu := super buildWindowMenu.
	menu addLine.
	menu add: 'inspect archive' target: archive action: #inspect.
	menu add: 'write prepending file...' target: self action: #writePrependingFile.
	^menu.