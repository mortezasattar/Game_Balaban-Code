using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Question Bank", menuName = "Quiz/Question Bank")]
public class QuestionBank : ScriptableObject
{
    public List<Question> questions = new List<Question>
    {
        new Question
        {
            questionText = "What does it mean to save money?",
            options = new string[] { "Spending all your cash", "Putting some aside for later", "Borrowing from friends", "Buying stuff right away" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why is saving money important?",
            options = new string[] { "To flex online", "For emergencies or future stuff", "So you can waste it later", "To fill your wallet" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Where's a safe place to keep savings?",
            options = new string[] { "Under your bed", "A bank account", "A cookie jar", "With a stranger" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What's an easy way to start saving?",
            options = new string[] { "Spend now, save later", "Set aside a little each time", "Gamble it", "Borrow weekly" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What does investing mean?",
            options = new string[] { "Spending fast", "Using money to make more", "Borrowing", "Hiding it" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Which is lowest-risk investment?",
            options = new string[] { "Crypto", "Stocks", "Savings account", "Starting a business" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "What are stocks?",
            options = new string[] { "Money you borrow", "Ownership in a company", "Gold", "Coupons" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s “risk” in finance?",
            options = new string[] { "Getting free money", "Chance to lose cash", "No impact", "Tax refund" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "“Reward” means...?",
            options = new string[] { "Free gift", "Profit earned", "Bonus from boss", "Tip from a friend" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Risk and reward...?",
            options = new string[] { "Aren’t linked", "High risk = low reward", "High risk = high reward", "Never mix" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "What is a budget?",
            options = new string[] { "Netflix list", "A money plan", "Gift card", "Store bill" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why budget matters?",
            options = new string[] { "Track cash and spending", "Get more coupons", "Buy faster", "Spend more" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "What’s a fixed expense?",
            options = new string[] { "Movie night", "Rent", "Snacks", "Shopping trips" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s a variable expense?",
            options = new string[] { "Rent", "Groceries", "Loan", "Internet" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What is debt?",
            options = new string[] { "Bonus money", "Cash you owe", "Gift from bank", "Free stuff" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "A credit card is...?",
            options = new string[] { "Gift card", "Loan tool", "Savings account", "Discount app" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "To repay debt means...?",
            options = new string[] { "Pay later", "Give it back", "Avoid it", "Lend it out" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s financial planning?",
            options = new string[] { "Party planning", "Organizing money goals", "Hiding cash", "Guessing budget" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s a financial goal?",
            options = new string[] { "Phone upgrade", "Save for school", "More coffee", "Daily snacks" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why set short + long goals?",
            options = new string[] { "For fun", "Make smarter choices", "Spend fast", "Avoid budgets" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What are taxes?",
            options = new string[] { "Government payments", "Free money", "Donations", "Store tips" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "What do taxes pay for?",
            options = new string[] { "Concerts", "Roads + schools", "Movie nights", "Lottery" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Income tax is based on...?",
            options = new string[] { "Your mood", "What you earn", "Job title", "Shopping" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s an entrepreneur?",
            options = new string[] { "Loan taker", "Starts a business", "Cashier", "Blogger" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "First step to start a biz?",
            options = new string[] { "Buy a desk", "Write a plan", "Post online", "Take a break" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why take risks in biz?",
            options = new string[] { "Avoid work", "Grow and profit", "Waste money", "Get lucky" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s financial ethics?",
            options = new string[] { "Avoiding bills", "Honest money use", "Free cash", "Ignore debt" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s ethical behavior with money?",
            options = new string[] { "Fake income", "Pay on time", "Use others’ cards", "Delay bills" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why be honest financially?",
            options = new string[] { "Get rich", "Build trust", "Hide cash", "Save faster" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Picking 2 phones — smart step?",
            options = new string[] { "Buy both", "Compare price + needs", "Ask friends", "Pick the brand" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Buying a game — what to check?",
            options = new string[] { "Budget", "Friend’s score", "Cool trailer", "How long it is" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Delay a purchase when...?",
            options = new string[] { "Feeling unsure", "You’re bored", "You’re paid", "It’s trending" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Earn $500/month — what to do?",
            options = new string[] { "Spend all", "Save some", "Lend it", "Upgrade phone" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Maria saves $50 monthly. After 10 months?",
            options = new string[] { "$100", "$250", "$600", "$500" },
            correctAnswerIndex = 3
        },
        new Question
        {
            questionText = "Best way to save each month?",
            options = new string[] { "Spend first", "Save randomly", "Set a goal and track it", "Borrow then save" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "You earn $100 a week. Save how much?",
            options = new string[] { "$10–20", "$200", "$95", "$0" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "You’ve saved $200, add $25/week. When will you hit $400?",
            options = new string[] { "10 weeks", "12 weeks", "16 weeks", "8 weeks" },
            correctAnswerIndex = 3
        },
        new Question
        {
            questionText = "What are bonds?",
            options = new string[] { "Stock shares", "Loans to companies/gov", "Savings accounts", "Debit cards" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Diversifying your investments...",
            options = new string[] { "Guarantees gains", "Spreads out risk", "Raises taxes", "Hurts returns" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "High returns often mean...?",
            options = new string[] { "No risk", "Lower interest", "Higher risk", "Easy wins" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Young and saving for retirement — best plan?",
            options = new string[] { "Only low-risk stuff", "All in cash", "Mix in higher-risk assets", "Avoid investing" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Why do high-risk options offer more reward?",
            options = new string[] { "No risk at all", "Bigger chance of big loss or win", "They’re safer", "They're controlled", "One stock only", "Nothing at all", "Bonds, stocks, funds", "Crypto + debt" },
            correctAnswerIndex = 6
        },
        new Question
        {
            questionText = "“Live within your means” means...?",
            options = new string[] { "Spend what you earn", "Use credit always", "Go over budget", "Take loans monthly" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Earn $2,000, spend $1,800 — that’s...?",
            options = new string[] { "Overspending", "Surplus", "Budget fail", "Breaking even" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Best tool for managing a budget?",
            options = new string[] { "Video app", "Credit card", "Budget app", "Social media" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "APR stands for...?",
            options = new string[] { "Annual Percentage Rate", "Payback range", "Bonus fee", "Extra loan" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Avoid debt traps by...?",
            options = new string[] { "Credit cards only", "No planning", "Budget + borrow smart", "Max loans" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Loan is $1,000, 10% rate. Interest owed?",
            options = new string[] { "$10", "$500", "$1,000", "$100" },
            correctAnswerIndex = 3
        },
        new Question
        {
            questionText = "What is a SMART goal?",
            options = new string[] { "Random one", "Clear + trackable", "Secret wish", "Guessing game" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Planning helps avoid...?",
            options = new string[] { "Saving", "Overspending", "Growth", "Side jobs" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Income drops — first move?",
            options = new string[] { "Party", "Adjust your plan", "Shop more", "Take a trip" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "A tax deduction does what?",
            options = new string[] { "Adds income", "Lowers taxes owed", "Gives refund", "Is optional" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Valid deduction?",
            options = new string[] { "TV", "Business cost", "Vacation", "Snacks" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "“Filing taxes” means...?",
            options = new string[] { "Send income info", "Pay bills", "Write a bio", "Budget day" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "A “pitch” is...?",
            options = new string[] { "Sales talk", "Bank form", "Receipt", "Logo" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Revenue is...?",
            options = new string[] { "Income earned", "Bonus", "Biz cost", "Bank fees" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "What’s bootstrapping?",
            options = new string[] { "Using own savings", "Big investor", "Tech stack", "Hiring fast" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Break-even point = ?",
            options = new string[] { "Costs = income", "Time to profit", "Loss", "Overhead" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Be transparent with money?",
            options = new string[] { "Hide expenses", "Be open", "Guess it", "Ignore it" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Unethical biz habit?",
            options = new string[] { "Mix personal + biz money", "Pay on time", "Log receipts", "Track costs" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Knowingly take big debt = ?",
            options = new string[] { "Smart move", "Unethical", "Free risk", "Credit bonus" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Rent or buy — what to compare?",
            options = new string[] { "Colors", "Flexibility + cost", "Store brand", "Friends’ homes" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "College — smart money step?",
            options = new string[] { "Pick fast", "Compare costs + aid", "Join trend", "Shop gear" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Used car over new — why?",
            options = new string[] { "Smells better", "Costs less", "Trendy", "More gas" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Grocery shopping — best tactic?",
            options = new string[] { "Buy what looks good", "Use list + compare prices", "Shop hungry", "Avoid store" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Why is compound interest great?",
            options = new string[] { "It grows on itself", "They subtract it", "Only paid once", "You get charged" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "How does inflation affect savings?",
            options = new string[] { "No effect", "Makes money worth less", "Grows your savings", "Adds bonuses" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s a high-yield savings account?",
            options = new string[] { "One with higher interest", "One with more fees", "Riskier account", "Locked account" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Why use multiple savings accounts?",
            options = new string[] { },
            correctAnswerIndex = -1
        },
        new Question
        {
            questionText = "12-A) Pay more tax",
            options = new string[] { "Lower your risk", "Lose money", "Save less", "Short-term savers", "Regular reinvestors", "One-time buyers", "Credit users" },
            correctAnswerIndex = 5
        },
        new Question
        {
            questionText = "What happens in a downturn?",
            options = new string[] { "Market rises", "Market drops", "Stays flat", "No change" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Real estate returns come from...?",
            options = new string[] { "Selling fast", "Rent + value growth", "Interest", "Dividends" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Key to choosing based on risk?",
            options = new string[] { "Pick your favorite brand", "Look at others", "Know your goals", "Ask a stranger" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Big short-term returns = ?",
            options = new string[] { "Guaranteed growth", "Low risk", "High volatility", "Tax-free" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "What’s hedging risk?",
            options = new string[] { "Ignore it", "Take more risk", "Reduce losses", "Sell all at once" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Good long-term budget includes...?",
            options = new string[] { "Just coffee plans", "Adjust + review", "Ignore bills", "No savings" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s a “sinking fund”?",
            options = new string[] { "Savings for big stuff", "Cruise money", "Loan", "Emergency use" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "No room to save in budget? Do what?",
            options = new string[] { "Buy more", "Take a trip", "Cut non-essentials", "Skip it" },
            correctAnswerIndex = 2
        },
        new Question
        {
            questionText = "Pay card minimum on $5k debt = ?",
            options = new string[] { "Quick payoff", "Over 10 years", "Free rewards", "1 month" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Snowball method = ?",
            options = new string[] { "Pay small debts first", "Big loans only", "Take more debt", "Skip interest" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Credit use above 30% = ?",
            options = new string[] { "Boost score", "Hurt credit", "Save fees", "Lower bills" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s asset allocation?",
            options = new string[] { "Splitting investments", "Selling stocks", "Loan method", "Credit use" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Tool to plan future expenses?",
            options = new string[] { "Calendar", "Budget sheet", "Meme app", "Expense list" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Good plan includes...?",
            options = new string[] { "Just cash", "Savings, investing, safety", "One account", "One goal" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "What’s the difference between tax avoidance and tax evasion?",
            options = new string[] { "Both are illegal", "One’s smart, one’s criminal", "Neither matters", "Just depends on mood" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "A tax-deferred account means...?",
            options = new string[] { "Pay tax later", "No tax ever", "Pay upfront", "Tax-free forever" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Why do high earners hire tax pros?",
            options = new string[] { "Skip budgeting", "Lower taxes legally", "Share memes", "Hide money" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Venture capital is...?",
            options = new string[] { "Startup investment", "Gov fund", "Bonus card", "Biz fee" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Crowdfunding = ?",
            options = new string[] { "Bank loan", "Public donations online", "Free cash", "Sponsor ad" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Burn rate is...?",
            options = new string[] { "Spending speed", "Profit", "Budget bonus", "Loan payoff" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Conflict of interest = ?",
            options = new string[] { "Two bank accounts", "Personal gain affects others", "Holding stocks", "Net loss" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Insider trading is...?",
            options = new string[] { "Fine if secret", "Unethical & illegal", "Trendy investing", "Normal" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Show integrity = ?",
            options = new string[] { "Hide errors", "Report truth", "Spin profits", "Inflate gains" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Ethical advisor must...?",
            options = new string[] { "Sell fast", "Focus on client needs", "Push products", "Skip details" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Social investors avoid...?",
            options = new string[] { "Polluters", "Tech stocks", "Fast food", "Small brands" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Moving cities — smart step?",
            options = new string[] { "Guess rent", "Research costs", "Pick vibe", "Avoid planning" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "Cashback card works if...?",
            options = new string[] { "You pay in full", "You spend big", "You skip tracking", "You max it out" },
            correctAnswerIndex = 0
        },
        new Question
        {
            questionText = "Got a raise — what next?",
            options = new string[] { "Party", "Save more", "Upgrade car", "Spend it all" },
            correctAnswerIndex = 1
        },
        new Question
        {
            questionText = "When to buy a house?",
            options = new string[] { "When pressured", "With savings + plan", "Right after job", "After 1st paycheck" },
            correctAnswerIndex = 1
        }
    };

}
