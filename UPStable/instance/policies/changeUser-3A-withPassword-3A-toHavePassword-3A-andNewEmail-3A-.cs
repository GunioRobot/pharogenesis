changeUser: user withPassword: password toHavePassword: newPassword andNewEmail: newEmail
	"the changes must be made on the server, not over the standard protocol"
	^UPolicyResponse denied