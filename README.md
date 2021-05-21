
# Step test data evalutation

## Evaluation of the program

The step test is a test that permit to calculate the fitness rating of a participant based on his or her heart rate after having done the test several times but also based on her or his age and the high of the step. Tn the testing process we start with the calculation of the aerobic capacity thanks to a linear extrapolation of the right created with the heart rate and the levels (linked to the step high). The aerobic capacity corresponds to the step test level associated with the max HR of the participant (which is equal to 220 minus their age). Once this aerobic capacity is determined to get the Fitness rating it is necessary to search in a gird for the correct fitness rating.

To make this testing process easier I made a program that handle the different steps of the test. The goal was to have an easy-to-use and intuitive program.

![](RackMultipart20210521-4-1txs7lf_html_27a06d73cf5f3a77.png)

![](RackMultipart20210521-4-1txs7lf_html_b9adef8778805f6f.png)When you open the program, you arrive at this view that act as a main menu. Each button explains clearly what it is doing. Here you can see a previous test, begin a new test, open a test that has already begun and import a list of participants. The help button is here to help with the file format needed to create a text file with the participant&#39;s info that can be imported into the program.

![](RackMultipart20210521-4-1txs7lf_html_66b22f9285f58ad.png) 
What could have been improved on this form could be a better explanation of how to import a file. Perhaps should I have provided an example file.

The second form is the form used to see all the previous tests. It is displaying a list of all the tests that have been saved to the database. A text field is here to permit to search a participant. Maybe should I have included a way to be able to search for a test done on a specific date or a specific score. However, it is very easy to search because the user does not even have to click on a search button. He only must type, and the results are automatically updated.

To delete a test the user just must click on a test and click on the delete test button.

Maybe a usability feature that could have been implemented is that when this window is open the main menu form closes down and when this form is closed the main menu form is reopened.

The last form of the program is the test form. When you open this form, you first must enter all the information about the participant. The rest of the interface is hidden, so the user can focus on this important information to collect.

![](RackMultipart20210521-4-1txs7lf_html_6408f5fae2a40532.png)

![](RackMultipart20210521-4-1txs7lf_html_54fa01ecf6cf925b.png)If the typed age is not correct either because the age is not in the correct bounds or because the user does not type a correct number an error message appears.

![](RackMultipart20210521-4-1txs7lf_html_c324640631bdf6fb.png) ![](RackMultipart20210521-4-1txs7lf_html_ff7388584afd03f4.png)The same principle is applied for the step high value. Knowing that if the user click on the arrow he will see all the step high possibilities.

Once all the required data are correctly typed the rest of the interface will be displayed.

![](RackMultipart20210521-4-1txs7lf_html_eb460e33ee779c8b.png)

As you can see here some information like the Max HR are already displayed and the program tells the user what the participant has to do.

One again there is a security to be sure that the user enters a correct number in the text box.

Once the validate button is clicked for the first time the age and step high input are make uneditable because if the were changed they may change some key data of the test. As you can see the results of the test are displayed as available on the screen.

![](RackMultipart20210521-4-1txs7lf_html_f5baf9de34c3b2b.png)

Once the test is finished the program display the aerobic capacity of the participant as well as his or her fitness rating. A graph is also displayed. This may help the user of the program that are used to use the graph to calculate the results.

It is only at this moment that the program saves the test into the database. Until then, it is uniquely stored as a Current test Class in a list in the main form.

This could be improved, especially the graph, which could be made more easy to read and could present more information like the right between all the points.

![](RackMultipart20210521-4-1txs7lf_html_16926f8f7a66720b.png)

If only one points is in the scope of HR which is considered as acceptable, then the program tries to calculate the fitness capacity of the participant by using the value that is the less out of the bounds and indicates it to the user.

![](RackMultipart20210521-4-1txs7lf_html_9a0b09f50179b7f.png)

Lastly if there isn't any valid HR measure the program also display it to the user.

![](RackMultipart20210521-4-1txs7lf_html_5c65d9767e37b819.png)

What could differentiate this program from the others is that it is very fast to begin a new test with a new participant. You don&#39;t have to create a participant in a window and begin the test in another one. All is done in the same window. You can also have multiple windows with multiple participant simultaneously.

The biggest improvement that could be made to usability in this form could be to be able to change from participant without having to go back to the main menu form.

Another improvement that could be done is that if the main menu is closed the complete program is closed and the data of the test that were not finish are lost. Maybe could it be good to have a security to prevent this.

To conclude we can say that this program is quite easy to use, there is not complicated manipulation to do. Therefore, it is also offering a complete range of functionality like the possibility to import a file with the participants information or the possibility to change from one participant&#39;s test to another at any moment. The only feature that can be complicated to get to grips with is the import of participants because of the required format that the file must have.

The design of the app is quite basic and simple, but this could be considered as a good point usability wise because the user will not be loose by it.

The way the program works is globally the same as what I describe in the first design document. The biggest difference is that I only write the results in the database at the end of the test and I use a Current test class to save the data of the test while he is happening. This permit the test to be faster because writing in the database take some time. Writing the last info at every step as describe in my original design would lead to slowing down the program and storing useless data in the database.

## Testing strategy

The purpose of this program is to calculate the fitness rating of the participant. Thus, it is very important that the fitness rating calculation is as accurate as possible. For this it is important to make tests to check that the calculation is well executed.

To make sure that there are no errors I perform each of the following four tests each time I modify the code:

Test 1: 17 years old, Male, 15 cm step high, HR 1: 97, HR 2: 110, HR 3: 135, HR 4: 140, HR 5: 180

Test 2: 24 years old, female, 20 cm step high, HR 1: 110, HR 2: 125, HR 3: 160, HR 4: 180

Test 3: 50 years old, female, 25 cm step high, HR 1: 110, HR 2: 145

Test 4: 35 years old, Male, 30 cm step high, HR 1: 90, HR 2: 104, HR 3: 115, HR 4: 130, HR 5: 146

What we have to do first is to calculate the aerobic capacity and the fitness rating of our 4 tests. To do it we will first use Microsoft Excel to interpolate the right between the point made of the valid HR and the step high. From this we will be able to get the aerobic capacity. After we will use the graph to get the fitness rating of our four tests.

According to excel interpolation program we found the following right equations:

Test 1: HR = 4,3919x + 50,743

Text 2: HR = 5,4508x + 40,82

Test 3: HR = 7x + 12

Test 4: HR = 2,596x + 47,946

With these equation we are able to calculate the aerobic capacity :

Test 1:

Test 2:

Test 3:

Test 4:

Now using the grid, we are able to determine the fitness rating of our tests:

Test 1: Below average

Test 2: Poor

Test 3: Below average

Test 4: Excellent

After executing the tests on my program, we get the following results:

Test 1: 35 Poor

Test 2: 28 Poor

Test 3: 23 Excellent

Test 4: 53 Average

As we can see the aerobic capacity is quite correct even if it is a bit overestimated it is less false than what would be done by hand (the example of the courses is underestimated by 13 compared to excel). However, the Fitness results are completely false. I made an update to the program and I get the following correct fitness rating:

Test 1: 42 average

Test 2: 29 below average

Test 3: 22 below average

Test 4: 60 Excellent

Thus, we can say that even if the algorithm is not perfect it is giving estimation that are not so far from reality.
