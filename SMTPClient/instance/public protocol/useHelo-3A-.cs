useHelo: aBoolean
	"Tell client to use HELO instead of EHLO. HELO is the old protocol and
	an old server may require it instead of EHLO."

	^self connectionInfo at: #useHelo put: aBoolean