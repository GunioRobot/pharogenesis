addOtherMorphsTo: aMorph
	| heights variableCount fraction offset vExtent h nonNavPanels |
	nonNavPanels := panels reject: [:ea | ea isNavigation].
	nonNavPanels isEmpty ifTrue: [^ self].
	heights _ nonNavPanels collect: [:ea | ea morphHeight].
	variableCount _ heights 
						inject: 0 
						into: [:count :ea | ea = 0 ifTrue: [count + 1] ifFalse: [count]].
	fraction _ self columnProportion.
	offset _ 0.
	vExtent _  1- fraction / variableCount.
	nonNavPanels with: heights do:  [:panel :height | 
		h _ height = 0 ifTrue: [vExtent] ifFalse: [0].
		aMorph 
			addMorph: panel morph
			fullFrame: (LayoutFrame
							fractions: (0@fraction extent: 1@h)
							offsets: (0@offset corner: 0@height)).
		height = 0 
			ifTrue: 	[offset _ 0.
					fraction _ fraction + vExtent]
			ifFalse: 	[offset _ offset + height]]
						
		
						