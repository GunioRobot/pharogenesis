reportLocalAddress
	"Report the local host address of this computer."

	| addrString m s |
	Socket initializeNetwork.
	addrString _ NetNameResolver localAddressString.
	m _ RectangleMorph new
		color: (Color r: 0.6 g: 0.8 b: 0.6);
		extent: 118@36;
		borderWidth: 1.
	s _ StringMorph contents: 'Local Host Address:'.
	s position: m position + (5@4).
	m addMorph: s.
	s _ StringMorph contents: addrString.
	s position: m position + (5@19).
	m addMorph: s.
	self attachMorph: m.
