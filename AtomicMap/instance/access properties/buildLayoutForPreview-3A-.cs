buildLayoutForPreview: aOwnerPanel 
	| style beginning item object newPos newBound |
	style _ AtomicMapStyle newForPreview.
	beginning _ aOwnerPanel bounds topRight.
	1
		to: layout rowCount
		do: [:r | 1
				to: layout  columnCount
				do: [:c | 
					item _ layout at: r at: c.
					object _ self createComponentsForPreview: item ..
					object
						ifNotNil: ["Specially for preview"
							object mapStyle: style.
							previewExtent _ previewExtent max: object previewPosition.
							newPos _ self atomPosition: object previewPosition - 1.
							newBound _ newPos corner: newPos + self atomSize.
							newBound _ newBound translateBy: beginning.
							object bounds: newBound.
							aOwnerPanel addMorph: object]]]