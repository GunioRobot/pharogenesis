chatFrom: ipAddress name: senderName text: text

	| initialText attrib |

	recipientForm ifNil: [
		initialText _ senderName asText allBold.
	] ifNotNil: [
		attrib _ TextAnchor new anchoredMorph: recipientForm "asMorph".
		initialText _ (String value: 1) asText.
		initialText addAttribute: attrib from: 1 to: 1.
	].
	self appendMessage: initialText,' - ',text,String cr.
	EToyCommunicatorMorph playArrivalSound.


