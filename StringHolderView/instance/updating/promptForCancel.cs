promptForCancel
	"Ask if it is OK to cancel changes to text"
	| okToCancel stripes |
	self topView isCollapsed ifTrue:
		[(self confirm: 'Changes have not been saved.
Is it OK to cancel those changes?') ifTrue: [model clearUserEditFlag].
		^ self].
	stripes _ (Form extent: 16@16 fromStipple: 16r36C9) bits.
	Display border: self insetDisplayBox width: 4
			rule: Form reverse fillColor: stripes.
	okToCancel _ self confirm: 'Changes have not been saved.
Is it OK to cancel those changes?'.
	Display border: self insetDisplayBox width: 4
			rule: Form reverse fillColor: stripes.
	okToCancel ifTrue:
		[self updateDisplayContents.
		model clearUserEditFlag].
