lastErrorCodeRange
	"Answer the brief error message for the last error"

	| aeDesc recordDesc data from to |
	aeDesc _ AEDesc new.
	recordDesc _ AEDesc new.
	Applescript generic
		primOSAScriptError: (DescType of: 'erng')
		type: (DescType of: 'erng')
		to: aeDesc.
	aeDesc
		primAECoerceDesc: (DescType of: 'reco')
		to: recordDesc.
	aeDesc dispose.
	data _ ByteArray new: 2.
	recordDesc
		primAEGetKeyPtr: (DescType of: 'srcs') 
		type: (DescType of: 'shor')
		actual: (DescType of: 'shor')
		to: data.
	from _ data shortAt: 1 bigEndian: true.
	recordDesc
		primAEGetKeyPtr: (DescType of: 'srce') 
		type: (DescType of: 'shor')
		actual: (DescType of: 'shor')
		to: data.
	to _ data shortAt: 1 bigEndian: true.
	recordDesc dispose.
	^ (from + 1) to: (to + 1)

