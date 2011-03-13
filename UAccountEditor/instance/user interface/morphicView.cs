morphicView
	| win column nameRow submitButton passwordRow password1Row password2Row emailRow submitButtonHolder |
	window ifNotNil: [^window].
	win := SystemWindow labelled: 'Account Editor'.
	win model: self.
	column := AlignmentMorph newColumn.
	win addMorph: column frame: (0 @ 0 extent: 1 @ 1).
	nameRow := UInterfaceUtilities 
				makeFieldRowNamed: 'name:'
				getSelector: #username
				setSelector: nil
				isPassword: false
				for: self.
	column addMorphBack: nameRow.
	passwordRow := UInterfaceUtilities 
				makeFieldRowNamed: 'password:'
				getSelector: #password
				setSelector: #password:
				isPassword: true
				for: self.
	column addMorphBack: passwordRow.
	password1Row := UInterfaceUtilities 
				makeFieldRowNamed: 'new password'
				getSelector: #password1
				setSelector: #password1:
				isPassword: true
				for: self.
	column addMorphBack: password1Row.
	password2Row := UInterfaceUtilities 
				makeFieldRowNamed: 'confirm:'
				getSelector: #password2
				setSelector: #password2:
				isPassword: true
				for: self.
	column addMorphBack: password2Row.
	emailRow := UInterfaceUtilities 
				makeFieldRowNamed: 'email:'
				getSelector: #newEmail
				setSelector: #newEmail:
				isPassword: false
				for: self.
	column addMorphBack: emailRow.
	submitButtonHolder := Morph new.	"necessary to keep SystemWindow from screwing up the colors of the button"
	submitButtonHolder
		layoutPolicy: TableLayout new;
		hResizing: #spaceFill;
		borderColor: self defaultBackgroundColor.
	submitButton := UInterfaceUtilities 
				makeButtonWithAction: #submit
				andLabel: 'Submit'
				for: self.
	submitButton
		useSquareCorners;
		borderWidth: 0.
	submitButtonHolder addMorph: submitButton.
	column addMorphBack: submitButtonHolder.
	^window := win