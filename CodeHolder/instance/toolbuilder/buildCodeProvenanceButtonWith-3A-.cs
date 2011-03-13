buildCodeProvenanceButtonWith: builder
	| buttonSpec |
	buttonSpec := builder pluggableActionButtonSpec new.
	buttonSpec model: self.
	buttonSpec label: #codePaneProvenanceString.
	buttonSpec action: #offerWhatToShowMenu.
	buttonSpec help: 'Governs what view is shown in the code pane.  Click here to change the view'.
	^buttonSpec