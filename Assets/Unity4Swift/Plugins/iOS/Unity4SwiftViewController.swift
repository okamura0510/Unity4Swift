class Unity4SwiftViewController : UIViewController {
    @objc var gameObjectName: String!
    
    @objc public func showAlertDialog(_ title: String, _ message: String, _ button: String, _ onClose: String) {
        let alert   = UIAlertController(title: title, message: message, preferredStyle: UIAlertControllerStyle.alert)
        let onClose = UIAlertAction(title: button, style: UIAlertActionStyle.default, handler: {
            (action: UIAlertAction!) -> Void in
            UnitySendMessage(self.gameObjectName, onClose, "完了しまうま")
        })
        alert.addAction(onClose)
        
        present(alert, animated: true, completion: nil)
    }
}
