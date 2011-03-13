editAccount
	| editor |
	self acceptFields.
	self closeAccountEditor.
	
	editor _ UAccountEditor
		username: username
		password: password
		email:  ''
		whenDone: [ :oldPassword :newPassword :newEmail |
			password _ oldPassword.
			self sendMessage: (UMEditAccount username: username password: password newPassword: newPassword newEmail: newEmail) ].
		
	editor openInMorphic.
	
	accountEditor _ editor.