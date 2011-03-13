buildWith: builder
	|  windowBuilder |

	windowBuilder := MCToolWindowBuilder builder: builder tool: self.
	self widgetSpecs do:
		[:spec | | send fractions offsets origin corner |
		send := spec first.
		fractions := spec at: 2 ifAbsent: [#(0 0 1 1)].
		offsets := spec at: 3 ifAbsent: [#(0 0 0 0)].
		origin := (offsets first @ offsets second) 
			/ self defaultExtent asFloatPoint
			+ (fractions first @ fractions second).
		corner := (offsets third @ offsets fourth) 
			/ self defaultExtent asFloatPoint
			+ (fractions third @ fractions fourth).
		windowBuilder frame: (origin corner: corner).
		windowBuilder perform: send first withArguments: send allButFirst].

	^ windowBuilder build
