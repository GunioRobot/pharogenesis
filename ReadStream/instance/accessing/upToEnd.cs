upToEnd
	| start |

	start _ position+1.
	position _ collection size.
	^collection copyFrom: start to: position