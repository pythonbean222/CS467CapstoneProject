I’m checking the interaction script now so I can tell you exactly where the number game should be opened from and what to hook up in the Inspector.

Reviewed ComputerInteraction.cs and searched for regex terms
Yes. The wiring point is ComputerInteraction.cs, not the input field itself.

Here is the flow:

Player presses the interact key near the computer.
ComputerInteraction.cs:41 runs.
That method calls onComputerInteraction.Invoke().
In the Unity Inspector, you attach one or more methods to that UnityEvent.
One of those methods should be NumberGuessingGame.cs:36 on your number guessing script.
So the event from ComputerInteraction is basically the trigger, and NumberGuessingGame is the thing that starts the puzzle.

How to wire it in Unity Editor:

Put ComputerInteraction on the computer trigger object.
Assign computerScreen if you want to show or hide the UI panel.
Put NumberGuessingGame on the UI or screen object that contains the prompt, feedback text, and input field.
In the NumberGuessingGame component, drag in:
promptText
feedbackText
guessInputField
On the ComputerInteraction component, find onComputerInteraction.
Click the plus button.
Drag the object that has NumberGuessingGame onto the event slot.
Choose NumberGuessingGame -> StartNewGame from the function dropdown.
That means pressing interact will fire the event, and that event will start the guessing round.

One important note: your current NumberGuessingGame.cs still has a broken if statement in StartNewGame, so it will not compile until that is fixed. Also, if your screen object starts disabled, you may want ComputerInteraction to turn it on before calling StartNewGame.

If you want, I can show you the exact clean setup for:

computerScreen turns on
NumberGuessingGame starts
input field gets focused
Completed: Wire guessing game into interaction script (3/4)

GPT-5.4 mini • 0.33x