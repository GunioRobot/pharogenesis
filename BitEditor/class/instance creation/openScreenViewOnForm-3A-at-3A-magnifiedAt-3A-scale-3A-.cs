openScreenViewOnForm: aForm at: formLocation magnifiedAt: magnifiedLocation scale: scaleFactor
	"Create and schedule a BitEditor on the form aForm. Show the magnified
	view of aForm in a scheduled window."
	| smallFormView bitEditor savedForm r |
	smallFormView := FormView new model: aForm.
	smallFormView align: smallFormView viewport topLeft with: formLocation.
	bitEditor := self bitEdit: aForm at: magnifiedLocation scale: scaleFactor remoteView: smallFormView.
	savedForm := Form fromDisplay: (r := bitEditor displayBox expandBy: (0@23 corner: 0@0)).
	bitEditor controller startUp.
	savedForm displayOn: Display at: r topLeft.
	bitEditor release.
	smallFormView release.

	"BitEditor magnifyOnScreen."