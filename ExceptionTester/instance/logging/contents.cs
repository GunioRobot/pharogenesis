contents

	^( self log
		inject: (WriteStream on: (String new: 80))
		into: 
			[:result :item |
			result 
				cr; 
				nextPutAll: item;
				yourself] ) contents