test06ClassDescriptionAllSubInstances


	
	| cdNo clsNo metaclsNo |

	cdNo _ ClassDescription allSubInstances size.
	clsNo _ Class allSubInstances size .
	metaclsNo _ Metaclass allSubInstances size.

	self assert: cdNo = (clsNo + metaclsNo).

	
	
	



	
	

	