groupLabelBorderStyleFor: aGroupPanel
	"Answer the normal border style for a group label."

	^BorderStyle simple
		width: 1;
		baseColor: (aGroupPanel paneColor lighter alphaMixed: 0.8 with: Color black)