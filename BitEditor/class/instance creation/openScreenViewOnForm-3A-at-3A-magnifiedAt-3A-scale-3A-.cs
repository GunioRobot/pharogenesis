openScreenViewOnForm: aForm at: formLocation magnifiedAt: magnifiedLocation scale: scaleFactor
	"Create and schedule a BitEditor on the form aForm. Show the magnified
	view of aForm in a scheduled window."
	| smallFormView bitEditor savedForm r |
	smallFormView _ FormView new model: aForm.
	smallFormView align: smallFormView viewport topLeft with: formLocation.
	bitEditor _ self bitEdit: aForm at: magnifiedLocation scale: scaleFactor remoteView: smallFormView.
	bitEditor controller blueButtonMenu: nil blueButtonMessages: nil.
	savedForm _ Form fromDisplay: (r _ bitEditor displayBox expandBy: (0@23 corner: 0@0)).
	bitEditor controller startUp.
	savedForm displayOn: Display at: r topLeft.
	bitEditor release.
	smallFormView release.

	"BitEditor magnifyOnScreen."