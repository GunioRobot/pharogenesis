imageClass: classSel comment: commentSel metaclass: metaclassSel 
	| env classCategory |
	env := OBMetaNode named: 'Environment'.
	classCategory := OBMetaNode named: 'ClassCategory'.
	env childAt: #categories put: classCategory.
	self addTo: classCategory class: classSel comment: commentSel metaclass: metaclassSel.
	^env