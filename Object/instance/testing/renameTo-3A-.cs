renameTo: newName
	"If the receiver has an inherent idea about its own name, it should take action here.  Any object that might be pointed to in the References dictionary might get this message sent to it upon reload"
	self flag: #ToCheckAfterEtoyRemoval.