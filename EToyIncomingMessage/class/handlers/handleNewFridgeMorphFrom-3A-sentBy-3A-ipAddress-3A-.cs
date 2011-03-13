handleNewFridgeMorphFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	| newObject |

	newObject _ self newObjectFromStream: dataStream.
	newObject
		setProperty: #fridgeSender toValue: senderName;
		setProperty: #fridgeIPAddress toValue: ipAddressString;
		setProperty: #fridgeDate toValue: Time dateAndTimeNow.
	WorldState addDeferredUIMessage: [EToyFridgeMorph newItem: newObject] fixTemps.
	