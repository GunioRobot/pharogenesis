fwdBlockGet
	"Return the address of a two-word forwarding block or nil if no more entries are available."

	fwdTableNext _ fwdTableNext + 8.
	fwdTableNext <= fwdTableLast
		ifTrue: [ ^ fwdTableNext ]
		ifFalse: [ ^ nil ].  "no more forwarding blocks available"