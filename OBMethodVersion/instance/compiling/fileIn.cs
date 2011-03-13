fileIn
	(self theClass) ifNotNilDo: [:class | class
						 				compile: self source 
										classified: self category 
										withStamp: self stamp 
										notifying: nil]
						
						