moreInfoOnSelectedContact
	|elem cab s |
	elem _ self selectedContactItem.
	cab _ (contactList at: elem).
	s _ ' User:'.
	cab firstName ifNotNil:[
		s _ s, cab firstName, ' '.
	].
	cab lastName ifNotNil:[
		s _ s, cab lastName.
	].
	s _ s, ' ' , cab email.
	s _ s,  ' Frequency:', (cab frequency asString).
	self alert:s.
	"Best alert of this but...if you like...
	 PopUpMenu inform: s."