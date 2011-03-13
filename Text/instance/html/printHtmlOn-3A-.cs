printHtmlOn: aStream 
	self runs
		withStartStopAndValueDo: [:start :stop :attributes | 
			| att str | 
			att := self attributesAt: start.
			str := self string copyFrom: start to: stop.
			""
			self openHtmlAttributes: att on: aStream.
			self printStringHtml: str on: aStream.

			self closeHtmlAttributes: att on: aStream]