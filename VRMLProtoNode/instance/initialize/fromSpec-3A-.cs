fromSpec: aNodeSpec
	nodeSpec := aNodeSpec.
	super fromSpec: aNodeSpec.
	protoType := (aNodeSpec attributeNamed:'protoType') value vrmlProtoCopy.