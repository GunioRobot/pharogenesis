hasYellowButtonMenu
	"Answer true if I have any items at all for a context (yellow button) menu."

	^self models anySatisfy: [ :m | m hasModelYellowButtonMenuItems ]