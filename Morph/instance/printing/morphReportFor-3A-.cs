morphReportFor: attributeList

	| s |

	s _ WriteStream on: String new.
	self
		morphReportFor: attributeList 
		on: s 
		indent: 0.
	StringHolder new contents: s contents; openLabel: 'morph report'