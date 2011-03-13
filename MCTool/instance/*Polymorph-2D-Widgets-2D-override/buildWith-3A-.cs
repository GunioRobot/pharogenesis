buildWith: builder
	|  windowBuilder |

	windowBuilder := MCToolWindowBuilder builder: builder tool: self.
	(windowBuilder respondsTo: #startWithWindow)
		ifTrue: [windowBuilder startWithWindow].
	self widgetSpecs do:
		[:spec | | send fractions offsets |
		send := spec first.
		fractions := spec at: 2 ifAbsent: [#(0 0 1 1)].
		offsets := spec at: 3 ifAbsent: [#(0 0 0 0)].
		windowBuilder frame: (LayoutFrame
			fractions: (fractions first @ fractions second corner: fractions third @ fractions fourth)
			offsets: (offsets first @ offsets second corner: offsets third @ offsets fourth)).
		windowBuilder perform: send first withArguments: send allButFirst].
	^ windowBuilder build