newDisplayBoxFor: subView adjoining: newRect along: side 
	side = #left ifTrue: [^ subView displayBox withRight: newRect left].
	side = #right ifTrue: [^ subView displayBox withLeft: newRect right].
	side = #top ifTrue: [^ subView displayBox withBottom: newRect top].
	side = #bottom ifTrue: [^ subView displayBox withTop: newRect bottom].