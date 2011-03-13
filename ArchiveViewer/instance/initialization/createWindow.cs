createWindow
	| list heading font text buttonBar |

	font := (TextStyle named: #DefaultFixedTextStyle)
		ifNotNilDo: [ :ts | ts fontArray first].

	buttonBar := self createButtonBar.
	self addMorph: buttonBar
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1.0@0.0) offsets: (0@0 corner: 0@44)).

	self minimumExtent: (buttonBar fullBounds width + 20) @ 230.
	self extent: self minimumExtent.

	heading := self createListHeadingUsingFont: font.
	self addMorph: heading
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1.0@0.0) offsets: (0@44 corner: 0@60)).

	(list := PluggableListMorph new)
		on: self list: #memberList
		selected: #memberIndex changeSelected: #memberIndex:
		menu: #memberMenu:shifted: keystroke: nil.
	list color: self defaultBackgroundColor.

	font ifNotNil: [list font: font].
	self addMorph: list
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1.0@0.8) offsets: (0@60 corner: 0@0)).

	text := PluggableTextMorph on: self 
			text: #contents accept: nil
			readSelection: nil menu: nil.
	self addMorph: text
		frame: (0@0.8 corner: 1.0@1.0).
	text lock.

	self setLabel: 'Ned''s Zip Viewer'