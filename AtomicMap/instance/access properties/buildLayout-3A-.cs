buildLayout: aOwnerPanel 
	| style beginning item object newPos newBound |
	style _ AtomicMapStyle new.
	beginning _ aOwnerPanel bounds bottomLeft.
	1
		to: layout rowCount
		do: [:r | 1
				to: layout columnCount
				do: [:c | 
					item _ layout at: r at: c.
					object _ self createComponents: item .
					object
						ifNotNil: [object mapStyle: style.
							newPos _ self atomPosition: r @ c - 1.
							newBound _ newPos corner: newPos + self atomSize.
							newBound _ newBound translateBy: beginning.
							object bounds: newBound.
							aOwnerPanel addMorphBack: object]]]