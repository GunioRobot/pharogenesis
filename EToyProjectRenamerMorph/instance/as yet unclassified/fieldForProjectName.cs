fieldForProjectName

	| tm |

	tm _ self genericTextFieldNamed: 'projectname'.
	tm setBalloonText: 'Pick a name 24 characters or less and avoid the following characters:

 : < > | / \ ? * " .'.
	^tm
	
