chooseOrientation
	| aMenu emphases reply |
	emphases _ #(vertical horizontal free).
	aMenu _ EmphasizedMenu selections: emphases.
	aMenu onlyBoldItem: (emphases indexOf: orientation).
	reply _ aMenu startUpWithCaption: 'Choose orientation'.
	(reply == nil or: [reply == orientation]) ifTrue: [^ self].
	self orientation: reply.
	self layoutChanged